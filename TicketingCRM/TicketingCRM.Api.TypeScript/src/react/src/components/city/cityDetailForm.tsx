import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CityMapper from './cityMapper';
import CityViewModel from './cityViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { EventTableComponent } from '../shared/eventTable';

interface CityDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CityDetailComponentState {
  model?: CityViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CityDetailComponent extends React.Component<
  CityDetailComponentProps,
  CityDetailComponentState
> {
  state = {
    model: new CityViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Cities + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.CityClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Cities +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new CityMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Province</h3>
              <p>
                {String(
                  this.state.model!.provinceIdNavigation &&
                    this.state.model!.provinceIdNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
          <div>
            <h3>Events</h3>
            <EventTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Cities +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Events
              }
            />
          </div>
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedCityDetailComponent = Form.create({ name: 'City Detail' })(
  CityDetailComponent
);


/*<Codenesium>
    <Hash>74413409600dd48e298497b778151555</Hash>
</Codenesium>*/
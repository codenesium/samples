import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProvinceMapper from './provinceMapper';
import ProvinceViewModel from './provinceViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { CityTableComponent } from '../shared/cityTable';
import { VenueTableComponent } from '../shared/venueTable';

interface ProvinceDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProvinceDetailComponentState {
  model?: ProvinceViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ProvinceDetailComponent extends React.Component<
  ProvinceDetailComponentProps,
  ProvinceDetailComponentState
> {
  state = {
    model: new ProvinceViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Provinces + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.ProvinceClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Provinces +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ProvinceMapper();

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
            <div style={{ marginBottom: '10px' }}>
              <h3>Country</h3>
              <p>
                {String(
                  this.state.model!.countryIdNavigation &&
                    this.state.model!.countryIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Cities</h3>
            <CityTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Provinces +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Cities
              }
            />
          </div>
          <div>
            <h3>Venues</h3>
            <VenueTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Provinces +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Venues
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

export const WrappedProvinceDetailComponent = Form.create({
  name: 'Province Detail',
})(ProvinceDetailComponent);


/*<Codenesium>
    <Hash>f3c306f7351069abe1c07d2e8b3c30ea</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
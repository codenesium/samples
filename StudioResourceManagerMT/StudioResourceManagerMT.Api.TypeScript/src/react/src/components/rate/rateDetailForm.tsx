import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import RateMapper from './rateMapper';
import RateViewModel from './rateViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface RateDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface RateDetailComponentState {
  model?: RateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class RateDetailComponent extends React.Component<
  RateDetailComponentProps,
  RateDetailComponentState
> {
  state = {
    model: new RateViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Rates + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.RateClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Rates +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new RateMapper();

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
              <h3>Amount Per Minute</h3>
              <p>{String(this.state.model!.amountPerMinute)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Teacher</h3>
              <p>
                {String(
                  this.state.model!.teacherIdNavigation &&
                    this.state.model!.teacherIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Teacher Skill</h3>
              <p>
                {String(
                  this.state.model!.teacherSkillIdNavigation &&
                    this.state.model!.teacherSkillIdNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedRateDetailComponent = Form.create({ name: 'Rate Detail' })(
  RateDetailComponent
);


/*<Codenesium>
    <Hash>b7ad0056611ddfc80804d2f1622fbe72</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
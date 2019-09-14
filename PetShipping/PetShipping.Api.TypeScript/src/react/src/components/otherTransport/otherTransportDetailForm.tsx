import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import OtherTransportMapper from './otherTransportMapper';
import OtherTransportViewModel from './otherTransportViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface OtherTransportDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface OtherTransportDetailComponentState {
  model?: OtherTransportViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class OtherTransportDetailComponent extends React.Component<
  OtherTransportDetailComponentProps,
  OtherTransportDetailComponentState
> {
  state = {
    model: new OtherTransportViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.OtherTransports + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.OtherTransportClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.OtherTransports +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new OtherTransportMapper();

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
              <h3>Handler</h3>
              <p>
                {String(
                  this.state.model!.handlerIdNavigation &&
                    this.state.model!.handlerIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Pipeline Step</h3>
              <p>
                {String(
                  this.state.model!.pipelineStepIdNavigation &&
                    this.state.model!.pipelineStepIdNavigation!.toDisplay()
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

export const WrappedOtherTransportDetailComponent = Form.create({
  name: 'OtherTransport Detail',
})(OtherTransportDetailComponent);


/*<Codenesium>
    <Hash>b2ad46cca5f783c6742377bd97001747</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
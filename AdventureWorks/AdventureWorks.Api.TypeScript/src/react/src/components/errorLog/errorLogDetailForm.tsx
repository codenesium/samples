import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ErrorLogMapper from './errorLogMapper';
import ErrorLogViewModel from './errorLogViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface ErrorLogDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ErrorLogDetailComponentState {
  model?: ErrorLogViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ErrorLogDetailComponent extends React.Component<
  ErrorLogDetailComponentProps,
  ErrorLogDetailComponentState
> {
  state = {
    model: new ErrorLogViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.ErrorLogs + '/edit/' + this.state.model!.errorLogID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.ErrorLogClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.ErrorLogs +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ErrorLogMapper();

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
              <h3>Error Line</h3>
              <p>{String(this.state.model!.errorLine)}</p>
            </div>
            <div>
              <h3>Error Message</h3>
              <p>{String(this.state.model!.errorMessage)}</p>
            </div>
            <div>
              <h3>Error Number</h3>
              <p>{String(this.state.model!.errorNumber)}</p>
            </div>
            <div>
              <h3>Error Procedure</h3>
              <p>{String(this.state.model!.errorProcedure)}</p>
            </div>
            <div>
              <h3>Error Severity</h3>
              <p>{String(this.state.model!.errorSeverity)}</p>
            </div>
            <div>
              <h3>Error State</h3>
              <p>{String(this.state.model!.errorState)}</p>
            </div>
            <div>
              <h3>Error Time</h3>
              <p>{String(this.state.model!.errorTime)}</p>
            </div>
            <div>
              <h3>User Name</h3>
              <p>{String(this.state.model!.userName)}</p>
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

export const WrappedErrorLogDetailComponent = Form.create({
  name: 'ErrorLog Detail',
})(ErrorLogDetailComponent);


/*<Codenesium>
    <Hash>8a7923dd345589831e5932b89e6b925b</Hash>
</Codenesium>*/
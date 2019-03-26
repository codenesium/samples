import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import LinkLogMapper from './linkLogMapper';
import LinkLogViewModel from './linkLogViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface LinkLogDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface LinkLogDetailComponentState {
  model?: LinkLogViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class LinkLogDetailComponent extends React.Component<
  LinkLogDetailComponentProps,
  LinkLogDetailComponentState
> {
  state = {
    model: new LinkLogViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.LinkLogs + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.LinkLogClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.LinkLogs +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new LinkLogMapper();

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
              <h3>DateEntered</h3>
              <p>{String(this.state.model!.dateEntered)}</p>
            </div>
            <div>
              <h3>Id</h3>
              <p>{String(this.state.model!.id)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>LinkId</h3>
              <p>
                {String(
                  this.state.model!.linkIdNavigation &&
                    this.state.model!.linkIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Log</h3>
              <p>{String(this.state.model!.log)}</p>
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

export const WrappedLinkLogDetailComponent = Form.create({
  name: 'LinkLog Detail',
})(LinkLogDetailComponent);


/*<Codenesium>
    <Hash>a53ea368a4993b2edcd371fa32be7319</Hash>
</Codenesium>*/
import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import LinkMapper from './linkMapper';
import LinkViewModel from './linkViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { LinkLogTableComponent } from '../shared/linkLogTable';

interface LinkDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface LinkDetailComponentState {
  model?: LinkViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class LinkDetailComponent extends React.Component<
  LinkDetailComponentProps,
  LinkDetailComponentState
> {
  state = {
    model: new LinkViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Links + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.LinkClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Links +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new LinkMapper();

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
              <h3>Assigned Machine</h3>
              <p>
                {String(
                  this.state.model!.assignedMachineIdNavigation &&
                    this.state.model!.assignedMachineIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Chain</h3>
              <p>
                {String(
                  this.state.model!.chainIdNavigation &&
                    this.state.model!.chainIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Date Completed</h3>
              <p>{String(this.state.model!.dateCompleted)}</p>
            </div>
            <div>
              <h3>Date Started</h3>
              <p>{String(this.state.model!.dateStarted)}</p>
            </div>
            <div>
              <h3>Dynamic Parameters</h3>
              <p>{String(this.state.model!.dynamicParameters)}</p>
            </div>
            <div>
              <h3>External</h3>
              <p>{String(this.state.model!.externalId)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Link Status</h3>
              <p>
                {String(
                  this.state.model!.linkStatusIdNavigation &&
                    this.state.model!.linkStatusIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div>
              <h3>Order</h3>
              <p>{String(this.state.model!.order)}</p>
            </div>
            <div>
              <h3>Response</h3>
              <p>{String(this.state.model!.response)}</p>
            </div>
            <div>
              <h3>Static Parameters</h3>
              <p>{String(this.state.model!.staticParameters)}</p>
            </div>
            <div>
              <h3>Timeout In Seconds</h3>
              <p>{String(this.state.model!.timeoutInSeconds)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>LinkLogs</h3>
            <LinkLogTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Links +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.LinkLogs
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

export const WrappedLinkDetailComponent = Form.create({ name: 'Link Detail' })(
  LinkDetailComponent
);


/*<Codenesium>
    <Hash>31488881ed2a08ef30665e78836cf786</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
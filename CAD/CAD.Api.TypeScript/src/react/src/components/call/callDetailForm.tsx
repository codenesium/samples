import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CallMapper from './callMapper';
import CallViewModel from './callViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { CallAssignmentTableComponent } from '../shared/callAssignmentTable';
import { NoteTableComponent } from '../shared/noteTable';

interface CallDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CallDetailComponentState {
  model?: CallViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CallDetailComponent extends React.Component<
  CallDetailComponentProps,
  CallDetailComponentState
> {
  state = {
    model: new CallViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Calls + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.CallClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Calls +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new CallMapper();

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
              <h3>addressId</h3>
              <p>
                {String(
                  this.state.model!.addressIdNavigation &&
                    this.state.model!.addressIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>callDispositionId</h3>
              <p>
                {String(
                  this.state.model!.callDispositionIdNavigation &&
                    this.state.model!.callDispositionIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>callStatusId</h3>
              <p>
                {String(
                  this.state.model!.callStatusIdNavigation &&
                    this.state.model!.callStatusIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>callString</h3>
              <p>{String(this.state.model!.callString)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>callTypeId</h3>
              <p>
                {String(
                  this.state.model!.callTypeIdNavigation &&
                    this.state.model!.callTypeIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>dateCleared</h3>
              <p>{String(this.state.model!.dateCleared)}</p>
            </div>
            <div>
              <h3>dateCreated</h3>
              <p>{String(this.state.model!.dateCreated)}</p>
            </div>
            <div>
              <h3>dateDispatched</h3>
              <p>{String(this.state.model!.dateDispatched)}</p>
            </div>
            <div>
              <h3>quickCallNumber</h3>
              <p>{String(this.state.model!.quickCallNumber)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>CallAssignments</h3>
            <CallAssignmentTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Calls +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.CallAssignments
              }
            />
          </div>
          <div>
            <h3>Notes</h3>
            <NoteTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Calls +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Notes
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

export const WrappedCallDetailComponent = Form.create({ name: 'Call Detail' })(
  CallDetailComponent
);


/*<Codenesium>
    <Hash>f31b2af3683e78024e2c21cb82078dba</Hash>
</Codenesium>*/
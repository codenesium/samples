import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CallMapper from './callMapper';
import CallViewModel from './callViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Calls +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.CallClientResponseModel;

          console.log(response);

          let mapper = new CallMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
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
                {String(this.state.model!.addressIdNavigation!.toDisplay())}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>callDispositionId</h3>
              <p>
                {String(
                  this.state.model!.callDispositionIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>callStatusId</h3>
              <p>
                {String(this.state.model!.callStatusIdNavigation!.toDisplay())}
              </p>
            </div>
            <div>
              <h3>callString</h3>
              <p>{String(this.state.model!.callString)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>callTypeId</h3>
              <p>
                {String(this.state.model!.callTypeIdNavigation!.toDisplay())}
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
              callId={this.state.model!.callId}
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
              id={this.state.model!.id}
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
    <Hash>22ef281c472378f178103778c2991b42</Hash>
</Codenesium>*/
import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import NoteMapper from './noteMapper';
import NoteViewModel from './noteViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface NoteDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface NoteDetailComponentState {
  model?: NoteViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class NoteDetailComponent extends React.Component<
  NoteDetailComponentProps,
  NoteDetailComponentState
> {
  state = {
    model: new NoteViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Notes + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Notes +
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
          let response = resp.data as Api.NoteClientResponseModel;

          console.log(response);

          let mapper = new NoteMapper();

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
              <h3>callId</h3>
              <p>{String(this.state.model!.callIdNavigation!.toDisplay())}</p>
            </div>
            <div>
              <h3>dateCreated</h3>
              <p>{String(this.state.model!.dateCreated)}</p>
            </div>
            <div>
              <h3>noteText</h3>
              <p>{String(this.state.model!.noteText)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>officerId</h3>
              <p>
                {String(this.state.model!.officerIdNavigation!.toDisplay())}
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

export const WrappedNoteDetailComponent = Form.create({ name: 'Note Detail' })(
  NoteDetailComponent
);


/*<Codenesium>
    <Hash>e6859f57098bcb89cfc26bc1e1815856</Hash>
</Codenesium>*/
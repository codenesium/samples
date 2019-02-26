import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FileTypeMapper from './fileTypeMapper';
import FileTypeViewModel from './fileTypeViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { FileTableComponent } from '../shared/fileTable';

interface FileTypeDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface FileTypeDetailComponentState {
  model?: FileTypeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class FileTypeDetailComponent extends React.Component<
  FileTypeDetailComponentProps,
  FileTypeDetailComponentState
> {
  state = {
    model: new FileTypeViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.FileTypes + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.FileTypes +
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
          let response = resp.data as Api.FileTypeClientResponseModel;

          console.log(response);

          let mapper = new FileTypeMapper();

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
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Files</h3>
            <FileTableComponent
              id={this.state.model!.id}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.FileTypes +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Files
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

export const WrappedFileTypeDetailComponent = Form.create({
  name: 'FileType Detail',
})(FileTypeDetailComponent);


/*<Codenesium>
    <Hash>d812e095948eabe8ca6da5ce323de7ca</Hash>
</Codenesium>*/
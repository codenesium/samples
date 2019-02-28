import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FileMapper from './fileMapper';
import FileViewModel from './fileViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface FileDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface FileDetailComponentState {
  model?: FileViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class FileDetailComponent extends React.Component<
  FileDetailComponentProps,
  FileDetailComponentState
> {
  state = {
    model: new FileViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Files + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Files +
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
          let response = resp.data as Api.FileClientResponseModel;

          console.log(response);

          let mapper = new FileMapper();

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
              <h3>BucketId</h3>
              <p>{String(this.state.model!.bucketIdNavigation!.toDisplay())}</p>
            </div>
            <div>
              <h3>DateCreated</h3>
              <p>{String(this.state.model!.dateCreated)}</p>
            </div>
            <div>
              <h3>Description</h3>
              <p>{String(this.state.model!.description)}</p>
            </div>
            <div>
              <h3>Expiration</h3>
              <p>{String(this.state.model!.expiration)}</p>
            </div>
            <div>
              <h3>Extension</h3>
              <p>{String(this.state.model!.extension)}</p>
            </div>
            <div>
              <h3>ExternalId</h3>
              <p>{String(this.state.model!.externalId)}</p>
            </div>
            <div>
              <h3>FileSizeInByte</h3>
              <p>{String(this.state.model!.fileSizeInByte)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>FileTypeId</h3>
              <p>
                {String(this.state.model!.fileTypeIdNavigation!.toDisplay())}
              </p>
            </div>
            <div>
              <h3>Location</h3>
              <p>{String(this.state.model!.location)}</p>
            </div>
            <div>
              <h3>PrivateKey</h3>
              <p>{String(this.state.model!.privateKey)}</p>
            </div>
            <div>
              <h3>PublicKey</h3>
              <p>{String(this.state.model!.publicKey)}</p>
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

export const WrappedFileDetailComponent = Form.create({ name: 'File Detail' })(
  FileDetailComponent
);


/*<Codenesium>
    <Hash>8a1bff5cb5dfe0eaba9d68f7b8d47021</Hash>
</Codenesium>*/
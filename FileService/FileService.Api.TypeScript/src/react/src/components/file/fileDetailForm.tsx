import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FileMapper from './fileMapper';
import FileViewModel from './fileViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

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
      .get<Api.FileClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Files +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new FileMapper();

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
              <h3>BucketId</h3>
              <p>
                {String(
                  this.state.model!.bucketIdNavigation &&
                    this.state.model!.bucketIdNavigation!.toDisplay()
                )}
              </p>
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
                {String(
                  this.state.model!.fileTypeIdNavigation &&
                    this.state.model!.fileTypeIdNavigation!.toDisplay()
                )}
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
    <Hash>f8d9d6076d79683870cd9fa43e1e1ff1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FileMapper from './fileMapper';
import FileViewModel from './fileViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

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
            loaded: false,
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
      return <LoadingForm />;
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
              <h3>bucketId</h3>
              <div>{this.state.model!.bucketIdNavigation!.toDisplay()}</div>
            </div>
            <div>
              <div>dateCreated</div>
              <div>{this.state.model!.dateCreated}</div>
            </div>
            <div>
              <div>description</div>
              <div>{this.state.model!.description}</div>
            </div>
            <div>
              <div>expiration</div>
              <div>{this.state.model!.expiration}</div>
            </div>
            <div>
              <div>extension</div>
              <div>{this.state.model!.extension}</div>
            </div>
            <div>
              <div>externalId</div>
              <div>{this.state.model!.externalId}</div>
            </div>
            <div>
              <div>fileSizeInByte</div>
              <div>{this.state.model!.fileSizeInByte}</div>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>fileTypeId</h3>
              <div>{this.state.model!.fileTypeIdNavigation!.toDisplay()}</div>
            </div>
            <div>
              <div>location</div>
              <div>{this.state.model!.location}</div>
            </div>
            <div>
              <div>privateKey</div>
              <div>{this.state.model!.privateKey}</div>
            </div>
            <div>
              <div>publicKey</div>
              <div>{this.state.model!.publicKey}</div>
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
    <Hash>ec8ac28042298d5b60c77cc1201a8fab</Hash>
</Codenesium>*/
import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DocumentMapper from './documentMapper';
import DocumentViewModel from './documentViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface DocumentDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface DocumentDetailComponentState {
  model?: DocumentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class DocumentDetailComponent extends React.Component<
  DocumentDetailComponentProps,
  DocumentDetailComponentState
> {
  state = {
    model: new DocumentViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Documents + '/edit/' + this.state.model!.rowguid
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Documents +
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
          let response = resp.data as Api.DocumentClientResponseModel;

          console.log(response);

          let mapper = new DocumentMapper();

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
              <h3>ChangeNumber</h3>
              <p>{String(this.state.model!.changeNumber)}</p>
            </div>
            <div>
              <h3>Document</h3>
              <p>{String(this.state.model!.document1)}</p>
            </div>
            <div>
              <h3>DocumentLevel</h3>
              <p>{String(this.state.model!.documentLevel)}</p>
            </div>
            <div>
              <h3>DocumentSummary</h3>
              <p>{String(this.state.model!.documentSummary)}</p>
            </div>
            <div>
              <h3>FileExtension</h3>
              <p>{String(this.state.model!.fileExtension)}</p>
            </div>
            <div>
              <h3>FileName</h3>
              <p>{String(this.state.model!.fileName)}</p>
            </div>
            <div>
              <h3>FolderFlag</h3>
              <p>{String(this.state.model!.folderFlag)}</p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Owner</h3>
              <p>{String(this.state.model!.owner)}</p>
            </div>
            <div>
              <h3>Revision</h3>
              <p>{String(this.state.model!.revision)}</p>
            </div>
            <div>
              <h3>rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
            <div>
              <h3>Status</h3>
              <p>{String(this.state.model!.status)}</p>
            </div>
            <div>
              <h3>Title</h3>
              <p>{String(this.state.model!.title)}</p>
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

export const WrappedDocumentDetailComponent = Form.create({
  name: 'Document Detail',
})(DocumentDetailComponent);


/*<Codenesium>
    <Hash>9f8668a341f4618e6804e50e8707512a</Hash>
</Codenesium>*/
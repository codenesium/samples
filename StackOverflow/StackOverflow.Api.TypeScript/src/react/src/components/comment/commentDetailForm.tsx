import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CommentMapper from './commentMapper';
import CommentViewModel from './commentViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface CommentDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CommentDetailComponentState {
  model?: CommentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CommentDetailComponent extends React.Component<
  CommentDetailComponentProps,
  CommentDetailComponentState
> {
  state = {
    model: new CommentViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Comments + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Comments +
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
          let response = resp.data as Api.CommentClientResponseModel;

          console.log(response);

          let mapper = new CommentMapper();

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
            <div>
              <div>creationDate</div>
              <div>{this.state.model!.creationDate}</div>
            </div>
            <div>
              <div>postId</div>
              <div>{this.state.model!.postId}</div>
            </div>
            <div>
              <div>score</div>
              <div>{this.state.model!.score}</div>
            </div>
            <div>
              <div>text</div>
              <div>{this.state.model!.text}</div>
            </div>
            <div>
              <div>userId</div>
              <div>{this.state.model!.userId}</div>
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

export const WrappedCommentDetailComponent = Form.create({
  name: 'Comment Detail',
})(CommentDetailComponent);


/*<Codenesium>
    <Hash>f80ac4594b42c4b47087c451497675b5</Hash>
</Codenesium>*/
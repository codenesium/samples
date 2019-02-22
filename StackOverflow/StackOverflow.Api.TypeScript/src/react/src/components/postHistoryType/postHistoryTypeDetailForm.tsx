import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostHistoryTypeMapper from './postHistoryTypeMapper';
import PostHistoryTypeViewModel from './postHistoryTypeViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface PostHistoryTypeDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PostHistoryTypeDetailComponentState {
  model?: PostHistoryTypeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PostHistoryTypeDetailComponent extends React.Component<
  PostHistoryTypeDetailComponentProps,
  PostHistoryTypeDetailComponentState
> {
  state = {
    model: new PostHistoryTypeViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.PostHistoryTypes + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.PostHistoryTypes +
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
          let response = resp.data as Api.PostHistoryTypeClientResponseModel;

          console.log(response);

          let mapper = new PostHistoryTypeMapper();

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
              <h3>Type</h3>
              <p>{String(this.state.model!.rwType)}</p>
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

export const WrappedPostHistoryTypeDetailComponent = Form.create({
  name: 'PostHistoryType Detail',
})(PostHistoryTypeDetailComponent);


/*<Codenesium>
    <Hash>7d97344c2387736c9516dfc4b83d5478</Hash>
</Codenesium>*/
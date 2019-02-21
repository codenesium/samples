import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TagMapper from './tagMapper';
import TagViewModel from './tagViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface TagDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TagDetailComponentState {
  model?: TagViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class TagDetailComponent extends React.Component<
  TagDetailComponentProps,
  TagDetailComponentState
> {
  state = {
    model: new TagViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Tags + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Tags +
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
          let response = resp.data as Api.TagClientResponseModel;

          console.log(response);

          let mapper = new TagMapper();

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
              <h3>Count</h3>
              <p>{String(this.state.model!.count)}</p>
            </div>
            <div>
              <h3>ExcerptPostId</h3>
              <p>{String(this.state.model!.excerptPostId)}</p>
            </div>
            <div>
              <h3>TagName</h3>
              <p>{String(this.state.model!.tagName)}</p>
            </div>
            <div>
              <h3>WikiPostId</h3>
              <p>{String(this.state.model!.wikiPostId)}</p>
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

export const WrappedTagDetailComponent = Form.create({ name: 'Tag Detail' })(
  TagDetailComponent
);


/*<Codenesium>
    <Hash>d29f2f2a02a3bc8e732c736c6a707d70</Hash>
</Codenesium>*/
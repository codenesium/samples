import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TagsMapper from './tagsMapper';
import TagsViewModel from './tagsViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface TagsDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TagsDetailComponentState {
  model?: TagsViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class TagsDetailComponent extends React.Component<
  TagsDetailComponentProps,
  TagsDetailComponentState
> {
  state = {
    model: new TagsViewModel(),
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
          let response = resp.data as Api.TagsClientResponseModel;

          console.log(response);

          let mapper = new TagsMapper();

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
              <h3>Count</h3>
              <p>{String(this.state.model!.count)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Excerpt Post</h3>
              <p>
                {String(this.state.model!.excerptPostIdNavigation!.toDisplay())}
              </p>
            </div>
            <div>
              <h3>Tag Name</h3>
              <p>{String(this.state.model!.tagName)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Wiki Post</h3>
              <p>
                {String(this.state.model!.wikiPostIdNavigation!.toDisplay())}
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

export const WrappedTagsDetailComponent = Form.create({ name: 'Tags Detail' })(
  TagsDetailComponent
);


/*<Codenesium>
    <Hash>ab097e1ae47ef227efd0a05171b8cbbd</Hash>
</Codenesium>*/
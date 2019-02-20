import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TagMapper from './tagMapper';
import TagViewModel from './tagViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

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
              <div>count</div>
              <div>{this.state.model!.count}</div>
            </div>
            <div>
              <div>excerptPostId</div>
              <div>{this.state.model!.excerptPostId}</div>
            </div>
            <div>
              <div>tagName</div>
              <div>{this.state.model!.tagName}</div>
            </div>
            <div>
              <div>wikiPostId</div>
              <div>{this.state.model!.wikiPostId}</div>
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
    <Hash>e2dee8572d3f94355d7cb746f28b9c36</Hash>
</Codenesium>*/
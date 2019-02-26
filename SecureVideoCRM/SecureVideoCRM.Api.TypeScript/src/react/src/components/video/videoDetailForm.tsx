import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VideoMapper from './videoMapper';
import VideoViewModel from './videoViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface VideoDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VideoDetailComponentState {
  model?: VideoViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class VideoDetailComponent extends React.Component<
  VideoDetailComponentProps,
  VideoDetailComponentState
> {
  state = {
    model: new VideoViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Videos + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Videos +
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
          let response = resp.data as Api.VideoClientResponseModel;

          console.log(response);

          let mapper = new VideoMapper();

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
              <h3>description</h3>
              <p>{String(this.state.model!.description)}</p>
            </div>
            <div>
              <h3>title</h3>
              <p>{String(this.state.model!.title)}</p>
            </div>
            <div>
              <h3>url</h3>
              <p>{String(this.state.model!.url)}</p>
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

export const WrappedVideoDetailComponent = Form.create({
  name: 'Video Detail',
})(VideoDetailComponent);


/*<Codenesium>
    <Hash>9b04863c7fa2a445a2755fe8e216e29d</Hash>
</Codenesium>*/
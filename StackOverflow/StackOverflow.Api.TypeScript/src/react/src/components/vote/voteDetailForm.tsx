import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VoteMapper from './voteMapper';
import VoteViewModel from './voteViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface VoteDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VoteDetailComponentState {
  model?: VoteViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class VoteDetailComponent extends React.Component<
  VoteDetailComponentProps,
  VoteDetailComponentState
> {
  state = {
    model: new VoteViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Votes + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Votes +
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
          let response = resp.data as Api.VoteClientResponseModel;

          console.log(response);

          let mapper = new VoteMapper();

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
              <h3>BountyAmount</h3>
              <p>{String(this.state.model!.bountyAmount)}</p>
            </div>
            <div>
              <h3>CreationDate</h3>
              <p>{String(this.state.model!.creationDate)}</p>
            </div>
            <div>
              <h3>PostId</h3>
              <p>{String(this.state.model!.postId)}</p>
            </div>
            <div>
              <h3>UserId</h3>
              <p>{String(this.state.model!.userId)}</p>
            </div>
            <div>
              <h3>VoteTypeId</h3>
              <p>{String(this.state.model!.voteTypeId)}</p>
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

export const WrappedVoteDetailComponent = Form.create({ name: 'Vote Detail' })(
  VoteDetailComponent
);


/*<Codenesium>
    <Hash>abeb905780a9bdeffd344fbb12da6b12</Hash>
</Codenesium>*/
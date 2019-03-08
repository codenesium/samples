import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VotesMapper from './votesMapper';
import VotesViewModel from './votesViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface VotesDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VotesDetailComponentState {
  model?: VotesViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class VotesDetailComponent extends React.Component<
  VotesDetailComponentProps,
  VotesDetailComponentState
> {
  state = {
    model: new VotesViewModel(),
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
          let response = resp.data as Api.VotesClientResponseModel;

          console.log(response);

          let mapper = new VotesMapper();

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
              <h3>Bounty Amount</h3>
              <p>{String(this.state.model!.bountyAmount)}</p>
            </div>
            <div>
              <h3>Creation Date</h3>
              <p>{String(this.state.model!.creationDate)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Post</h3>
              <p>{String(this.state.model!.postIdNavigation!.toDisplay())}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>User</h3>
              <p>{String(this.state.model!.userIdNavigation!.toDisplay())}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Vote Type</h3>
              <p>
                {String(this.state.model!.voteTypeIdNavigation!.toDisplay())}
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

export const WrappedVotesDetailComponent = Form.create({
  name: 'Votes Detail',
})(VotesDetailComponent);


/*<Codenesium>
    <Hash>4638a327732282ea91dd55c0e40d18d6</Hash>
</Codenesium>*/
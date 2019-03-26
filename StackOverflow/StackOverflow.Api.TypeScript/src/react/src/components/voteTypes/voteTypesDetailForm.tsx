import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VoteTypesMapper from './voteTypesMapper';
import VoteTypesViewModel from './voteTypesViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { VotesTableComponent } from '../shared/votesTable';

interface VoteTypesDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface VoteTypesDetailComponentState {
  model?: VoteTypesViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class VoteTypesDetailComponent extends React.Component<
  VoteTypesDetailComponentProps,
  VoteTypesDetailComponentState
> {
  state = {
    model: new VoteTypesViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.VoteTypes + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.VoteTypesClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.VoteTypes +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new VoteTypesMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
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
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Votes</h3>
            <VotesTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.VoteTypes +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Votes
              }
            />
          </div>
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedVoteTypesDetailComponent = Form.create({
  name: 'VoteTypes Detail',
})(VoteTypesDetailComponent);


/*<Codenesium>
    <Hash>d7600066b61e1a1305daa1412ba122dd</Hash>
</Codenesium>*/
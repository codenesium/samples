import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import VoteMapper from './voteMapper';
import VoteViewModel from './voteViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

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
              <div>bountyAmount</div>
              <div>{this.state.model!.bountyAmount}</div>
            </div>
            <div>
              <div>creationDate</div>
              <div>{this.state.model!.creationDate}</div>
            </div>
            <div>
              <div>postId</div>
              <div>{this.state.model!.postId}</div>
            </div>
            <div>
              <div>userId</div>
              <div>{this.state.model!.userId}</div>
            </div>
            <div>
              <div>voteTypeId</div>
              <div>{this.state.model!.voteTypeId}</div>
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
    <Hash>5e8656d6e494348eb30770e8b7b28453</Hash>
</Codenesium>*/
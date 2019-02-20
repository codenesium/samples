import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import BadgeMapper from './badgeMapper';
import BadgeViewModel from './badgeViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface BadgeDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface BadgeDetailComponentState {
  model?: BadgeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class BadgeDetailComponent extends React.Component<
  BadgeDetailComponentProps,
  BadgeDetailComponentState
> {
  state = {
    model: new BadgeViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Badges + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Badges +
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
          let response = resp.data as Api.BadgeClientResponseModel;

          console.log(response);

          let mapper = new BadgeMapper();

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
              <div>date</div>
              <div>{this.state.model!.date}</div>
            </div>
            <div>
              <div>name</div>
              <div>{this.state.model!.name}</div>
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

export const WrappedBadgeDetailComponent = Form.create({
  name: 'Badge Detail',
})(BadgeDetailComponent);


/*<Codenesium>
    <Hash>79e9dbe002c3bc0039123de1ae0f3b84</Hash>
</Codenesium>*/
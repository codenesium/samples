import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ClaspMapper from './claspMapper';
import ClaspViewModel from './claspViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface ClaspDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ClaspDetailComponentState {
  model?: ClaspViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ClaspDetailComponent extends React.Component<
  ClaspDetailComponentProps,
  ClaspDetailComponentState
> {
  state = {
    model: new ClaspViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Clasps + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Clasps +
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
          let response = resp.data as Api.ClaspClientResponseModel;

          console.log(response);

          let mapper = new ClaspMapper();

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
              <h3>Id</h3>
              <p>{String(this.state.model!.id)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>NextChainId</h3>
              <p>
                {String(this.state.model!.nextChainIdNavigation!.toDisplay())}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>PreviousChainId</h3>
              <p>
                {String(
                  this.state.model!.previousChainIdNavigation!.toDisplay()
                )}
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

export const WrappedClaspDetailComponent = Form.create({
  name: 'Clasp Detail',
})(ClaspDetailComponent);


/*<Codenesium>
    <Hash>9db99c9c5f06a9dfecea6dd4a500d418</Hash>
</Codenesium>*/
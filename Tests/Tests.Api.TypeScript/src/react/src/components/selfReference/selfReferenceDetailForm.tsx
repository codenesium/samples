import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SelfReferenceMapper from './selfReferenceMapper';
import SelfReferenceViewModel from './selfReferenceViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface SelfReferenceDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SelfReferenceDetailComponentState {
  model?: SelfReferenceViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class SelfReferenceDetailComponent extends React.Component<
  SelfReferenceDetailComponentProps,
  SelfReferenceDetailComponentState
> {
  state = {
    model: new SelfReferenceViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.SelfReferences + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.SelfReferences +
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
          let response = resp.data as Api.SelfReferenceClientResponseModel;

          console.log(response);

          let mapper = new SelfReferenceMapper();

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
              <h3>SelfReferenceId</h3>
              <p>
                {String(
                  this.state.model!.selfReferenceIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>SelfReferenceId2</h3>
              <p>
                {String(
                  this.state.model!.selfReferenceId2Navigation!.toDisplay()
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

export const WrappedSelfReferenceDetailComponent = Form.create({
  name: 'SelfReference Detail',
})(SelfReferenceDetailComponent);


/*<Codenesium>
    <Hash>abf0234b850d75d5e945a029f832c65b</Hash>
</Codenesium>*/
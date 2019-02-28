import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import StudioMapper from './studioMapper';
import StudioViewModel from './studioViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface StudioDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface StudioDetailComponentState {
  model?: StudioViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class StudioDetailComponent extends React.Component<
  StudioDetailComponentProps,
  StudioDetailComponentState
> {
  state = {
    model: new StudioViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Studios + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Studios +
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
          let response = resp.data as Api.StudioClientResponseModel;

          console.log(response);

          let mapper = new StudioMapper();

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
              <h3>address1</h3>
              <p>{String(this.state.model!.address1)}</p>
            </div>
            <div>
              <h3>address2</h3>
              <p>{String(this.state.model!.address2)}</p>
            </div>
            <div>
              <h3>city</h3>
              <p>{String(this.state.model!.city)}</p>
            </div>
            <div>
              <h3>id</h3>
              <p>{String(this.state.model!.id)}</p>
            </div>
            <div>
              <h3>name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div>
              <h3>province</h3>
              <p>{String(this.state.model!.province)}</p>
            </div>
            <div>
              <h3>website</h3>
              <p>{String(this.state.model!.website)}</p>
            </div>
            <div>
              <h3>zip</h3>
              <p>{String(this.state.model!.zip)}</p>
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

export const WrappedStudioDetailComponent = Form.create({
  name: 'Studio Detail',
})(StudioDetailComponent);


/*<Codenesium>
    <Hash>8a29430aea9c90dde0a8d9bb03b47965</Hash>
</Codenesium>*/
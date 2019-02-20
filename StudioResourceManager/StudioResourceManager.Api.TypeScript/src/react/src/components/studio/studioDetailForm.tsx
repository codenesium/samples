import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import StudioMapper from './studioMapper';
import StudioViewModel from './studioViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

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
              <div>address1</div>
              <div>{this.state.model!.address1}</div>
            </div>
            <div>
              <div>address2</div>
              <div>{this.state.model!.address2}</div>
            </div>
            <div>
              <div>city</div>
              <div>{this.state.model!.city}</div>
            </div>
            <div>
              <div>name</div>
              <div>{this.state.model!.name}</div>
            </div>
            <div>
              <div>province</div>
              <div>{this.state.model!.province}</div>
            </div>
            <div>
              <div>website</div>
              <div>{this.state.model!.website}</div>
            </div>
            <div>
              <div>zip</div>
              <div>{this.state.model!.zip}</div>
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
    <Hash>8ef850f96279ec0f7b98d0bacb6890a6</Hash>
</Codenesium>*/
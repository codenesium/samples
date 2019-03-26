import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import IllustrationMapper from './illustrationMapper';
import IllustrationViewModel from './illustrationViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { ProductModelIllustrationTableComponent } from '../shared/productModelIllustrationTable';

interface IllustrationDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface IllustrationDetailComponentState {
  model?: IllustrationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class IllustrationDetailComponent extends React.Component<
  IllustrationDetailComponentProps,
  IllustrationDetailComponentState
> {
  state = {
    model: new IllustrationViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Illustrations + '/edit/' + this.state.model!.illustrationID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.IllustrationClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Illustrations +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new IllustrationMapper();

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
              <h3>Diagram</h3>
              <p>{String(this.state.model!.diagram)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>ProductModelIllustrations</h3>
            <ProductModelIllustrationTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Illustrations +
                '/' +
                this.state.model!.illustrationID +
                '/' +
                ApiRoutes.ProductModelIllustrations
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

export const WrappedIllustrationDetailComponent = Form.create({
  name: 'Illustration Detail',
})(IllustrationDetailComponent);


/*<Codenesium>
    <Hash>4b59bf520d8f778663c03296621f7dd5</Hash>
</Codenesium>*/
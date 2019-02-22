import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CultureMapper from './cultureMapper';
import CultureViewModel from './cultureViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ProductModelProductDescriptionCultureTableComponent } from '../shared/productModelProductDescriptionCultureTable';

interface CultureDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CultureDetailComponentState {
  model?: CultureViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CultureDetailComponent extends React.Component<
  CultureDetailComponentProps,
  CultureDetailComponentState
> {
  state = {
    model: new CultureViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Cultures + '/edit/' + this.state.model!.cultureID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Cultures +
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
          let response = resp.data as Api.CultureClientResponseModel;

          console.log(response);

          let mapper = new CultureMapper();

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
              <h3>CultureID</h3>
              <p>{String(this.state.model!.cultureID)}</p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>ProductModelProductDescriptionCultures</h3>
            <ProductModelProductDescriptionCultureTableComponent
              productModelID={this.state.model!.productModelID}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Cultures +
                '/' +
                this.state.model!.cultureID +
                '/' +
                ApiRoutes.ProductModelProductDescriptionCultures
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

export const WrappedCultureDetailComponent = Form.create({
  name: 'Culture Detail',
})(CultureDetailComponent);


/*<Codenesium>
    <Hash>b2deca62d733b4222e79852fcad12c12</Hash>
</Codenesium>*/
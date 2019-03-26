import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UnitMeasureMapper from './unitMeasureMapper';
import UnitMeasureViewModel from './unitMeasureViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { BillOfMaterialTableComponent } from '../shared/billOfMaterialTable';
import { ProductTableComponent } from '../shared/productTable';

interface UnitMeasureDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface UnitMeasureDetailComponentState {
  model?: UnitMeasureViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class UnitMeasureDetailComponent extends React.Component<
  UnitMeasureDetailComponentProps,
  UnitMeasureDetailComponentState
> {
  state = {
    model: new UnitMeasureViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.UnitMeasures + '/edit/' + this.state.model!.unitMeasureCode
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.UnitMeasureClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.UnitMeasures +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new UnitMeasureMapper();

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
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>BillOfMaterials</h3>
            <BillOfMaterialTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.UnitMeasures +
                '/' +
                this.state.model!.unitMeasureCode +
                '/' +
                ApiRoutes.BillOfMaterials
              }
            />
          </div>
          <div>
            <h3>Products</h3>
            <ProductTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.UnitMeasures +
                '/' +
                this.state.model!.unitMeasureCode +
                '/' +
                ApiRoutes.Products
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

export const WrappedUnitMeasureDetailComponent = Form.create({
  name: 'UnitMeasure Detail',
})(UnitMeasureDetailComponent);


/*<Codenesium>
    <Hash>cc15df01f9838024c6be3783ab0d585d</Hash>
</Codenesium>*/
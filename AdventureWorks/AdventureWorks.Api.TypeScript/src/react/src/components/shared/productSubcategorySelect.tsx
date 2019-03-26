import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import * as Api from '../../api/models';
import ProductSubcategoryMapper from '../productSubcategory/productSubcategoryMapper';
import ProductSubcategoryViewModel from '../productSubcategory/productSubcategoryViewModel';
import { Form, Spin, Alert, Select } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface ProductSubcategorySelectComponentProps {
  getFieldDecorator: any;
  apiRoute: string;
  selectedValue: number;
  propertyName: string;
  required: boolean;
}

interface ProductSubcategorySelectComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<ProductSubcategoryViewModel>;
}

export class ProductSubcategorySelectComponent extends React.Component<
  ProductSubcategorySelectComponentProps,
  ProductSubcategorySelectComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.ProductSubcategoryClientResponseModel>>(
        this.props.apiRoute,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ProductSubcategoryMapper();

        let devices: Array<ProductSubcategoryViewModel> = [];

        response.data.forEach(x => {
          devices.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: devices,
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
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      return (
        <Form.Item>
          <label htmlFor={this.props.propertyName}>Product Subcategory</label>
          <br />
          {this.props.getFieldDecorator(this.props.propertyName, {
            initialValue: this.props.selectedValue || [],
            rules: [{ required: this.props.required, message: 'Required' }],
          })(
            <Select>
              {this.state.filteredRecords.map(
                (x: ProductSubcategoryViewModel) => {
                  return (
                    <Select.Option
                      key={x.productSubcategoryID}
                      value={x.productSubcategoryID}
                    >
                      {x.toDisplay()}
                    </Select.Option>
                  );
                }
              )}
            </Select>
          )}
        </Form.Item>
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>56dcca25447bf328728a1281d6cf1403</Hash>
</Codenesium>*/
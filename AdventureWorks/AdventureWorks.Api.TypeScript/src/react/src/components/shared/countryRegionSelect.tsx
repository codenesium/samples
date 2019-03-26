import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import * as Api from '../../api/models';
import CountryRegionMapper from '../countryRegion/countryRegionMapper';
import CountryRegionViewModel from '../countryRegion/countryRegionViewModel';
import { Form, Spin, Alert, Select } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface CountryRegionSelectComponentProps {
  getFieldDecorator: any;
  apiRoute: string;
  selectedValue: string;
  propertyName: string;
  required: boolean;
}

interface CountryRegionSelectComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<CountryRegionViewModel>;
}

export class CountryRegionSelectComponent extends React.Component<
  CountryRegionSelectComponentProps,
  CountryRegionSelectComponentState
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
      .get<Array<Api.CountryRegionClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new CountryRegionMapper();

        let devices: Array<CountryRegionViewModel> = [];

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
          <label htmlFor={this.props.propertyName}>Country Region</label>
          <br />
          {this.props.getFieldDecorator(this.props.propertyName, {
            initialValue: this.props.selectedValue || [],
            rules: [{ required: this.props.required, message: 'Required' }],
          })(
            <Select>
              {this.state.filteredRecords.map((x: CountryRegionViewModel) => {
                return (
                  <Select.Option
                    key={x.countryRegionCode}
                    value={x.countryRegionCode}
                  >
                    {x.toDisplay()}
                  </Select.Option>
                );
              })}
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
    <Hash>1c198dd422f58940d363d5913ac6adf9</Hash>
</Codenesium>*/
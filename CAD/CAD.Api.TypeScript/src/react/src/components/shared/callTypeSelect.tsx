import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import * as Api from '../../api/models';
import CallTypeMapper from '../callType/callTypeMapper';
import CallTypeViewModel from '../callType/callTypeViewModel';
import { Form, Spin, Alert, Select } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface CallTypeSelectComponentProps {
  getFieldDecorator: any;
  apiRoute: string;
  selectedValue: number;
  propertyName: string;
  required: boolean;
}

interface CallTypeSelectComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<CallTypeViewModel>;
}

export class CallTypeSelectComponent extends React.Component<
  CallTypeSelectComponentProps,
  CallTypeSelectComponentState
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
      .get<Array<Api.CallTypeClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new CallTypeMapper();

        let devices: Array<CallTypeViewModel> = [];

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
          <label htmlFor={this.props.propertyName}>
            Call Type {this.props.required ? ' (required)' : ' (optional)'}
          </label>
          <br />
          {this.props.getFieldDecorator(this.props.propertyName, {
            initialValue: this.props.selectedValue || [],
            rules: [{ required: this.props.required, message: 'Required' }],
          })(
            <Select>
              {this.state.filteredRecords.map((x: CallTypeViewModel) => {
                return (
                  <Select.Option key={String(x.id)} value={x.id}>
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
    <Hash>a0cad5e31c6023078900b4b0e27f9557</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import * as Api from '../../api/models';
import CustomerCommunicationMapper from '../customerCommunication/customerCommunicationMapper';
import CustomerCommunicationViewModel from '../customerCommunication/customerCommunicationViewModel';
import { Form, Spin, Alert, Select } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface CustomerCommunicationSelectComponentProps {
  getFieldDecorator: any;
  apiRoute: string;
  selectedValue: number;
  propertyName: string;
  required: boolean;
}

interface CustomerCommunicationSelectComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<CustomerCommunicationViewModel>;
}

export class CustomerCommunicationSelectComponent extends React.Component<
  CustomerCommunicationSelectComponentProps,
  CustomerCommunicationSelectComponentState
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
      .get<Array<Api.CustomerCommunicationClientResponseModel>>(
        this.props.apiRoute,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new CustomerCommunicationMapper();

        let devices: Array<CustomerCommunicationViewModel> = [];

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
          <label htmlFor={this.props.propertyName} />
          <br />
          {this.props.getFieldDecorator(this.props.propertyName, {
            initialValue: this.props.selectedValue || [],
            rules: [{ required: this.props.required, message: 'Required' }],
          })(
            <Select>
              {this.state.filteredRecords.map(
                (x: CustomerCommunicationViewModel) => {
                  return (
                    <Select.Option key={x.id} value={x.id}>
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
    <Hash>715c9e76a4914bfe966f9a71fee4dbb4</Hash>
</Codenesium>*/
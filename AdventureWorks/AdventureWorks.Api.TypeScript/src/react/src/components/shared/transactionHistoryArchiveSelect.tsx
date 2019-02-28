import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import TransactionHistoryArchiveMapper from '../transactionHistoryArchive/transactionHistoryArchiveMapper';
import TransactionHistoryArchiveViewModel from '../transactionHistoryArchive/transactionHistoryArchiveViewModel';
import { Spin, Alert, Select } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface TransactionHistoryArchiveSelectComponentProps {
  getFieldDecorator: any;
  apiRoute: string;
  selectedValue: number;
  propertyName: string;
  required: boolean;
}

interface TransactionHistoryArchiveSelectComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<TransactionHistoryArchiveViewModel>;
}

export class TransactionHistoryArchiveSelectComponent extends React.Component<
  TransactionHistoryArchiveSelectComponentProps,
  TransactionHistoryArchiveSelectComponentState
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
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<
            Api.TransactionHistoryArchiveClientResponseModel
          >;

          console.log(response);

          let mapper = new TransactionHistoryArchiveMapper();

          let devices: Array<TransactionHistoryArchiveViewModel> = [];

          response.forEach(x => {
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
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
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
      return <Spin size="large" />;
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      return (
        <div>
          {this.props.getFieldDecorator(this.props.propertyName, {
            initialValue: this.props.selectedValue,
            rules: [{ required: this.props.required, message: 'Required' }],
          })(
            <Select>
              {this.state.filteredRecords.map(
                (x: TransactionHistoryArchiveViewModel) => {
                  return (
                    <Select.Option value={x.transactionID}>
                      {x.toDisplay()}
                    </Select.Option>
                  );
                }
              )}
            </Select>
          )}
        </div>
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>f5fb21e997fe4ff266a1e1bc211fee6c</Hash>
</Codenesium>*/
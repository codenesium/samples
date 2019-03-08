import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import CommentsMapper from '../comments/commentsMapper';
import CommentsViewModel from '../comments/commentsViewModel';
import { Spin, Alert, Select } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface CommentsSelectComponentProps {
  getFieldDecorator: any;
  apiRoute: string;
  selectedValue: number;
  propertyName: string;
  required: boolean;
}

interface CommentsSelectComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<CommentsViewModel>;
}

export class CommentsSelectComponent extends React.Component<
  CommentsSelectComponentProps,
  CommentsSelectComponentState
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
          let response = resp.data as Array<Api.CommentsClientResponseModel>;

          console.log(response);

          let mapper = new CommentsMapper();

          let devices: Array<CommentsViewModel> = [];

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
              {this.state.filteredRecords.map((x: CommentsViewModel) => {
                return (
                  <Select.Option value={x.id}>{x.toDisplay()}</Select.Option>
                );
              })}
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
    <Hash>65ef8f0e247f896406ca3612744b4432</Hash>
</Codenesium>*/
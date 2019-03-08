import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import PipelineStepDestinationMapper from '../pipelineStepDestination/pipelineStepDestinationMapper';
import PipelineStepDestinationViewModel from '../pipelineStepDestination/pipelineStepDestinationViewModel';
import { Spin, Alert, Select } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface PipelineStepDestinationSelectComponentProps {
  getFieldDecorator: any;
  apiRoute: string;
  selectedValue: number;
  propertyName: string;
  required: boolean;
}

interface PipelineStepDestinationSelectComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<PipelineStepDestinationViewModel>;
}

export class PipelineStepDestinationSelectComponent extends React.Component<
  PipelineStepDestinationSelectComponentProps,
  PipelineStepDestinationSelectComponentState
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
            Api.PipelineStepDestinationClientResponseModel
          >;

          console.log(response);

          let mapper = new PipelineStepDestinationMapper();

          let devices: Array<PipelineStepDestinationViewModel> = [];

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
                (x: PipelineStepDestinationViewModel) => {
                  return (
                    <Select.Option value={x.id}>{x.toDisplay()}</Select.Option>
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
    <Hash>d4723d680165bf5ed785478ebc44d373</Hash>
</Codenesium>*/
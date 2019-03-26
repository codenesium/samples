import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ShiftMapper from './shiftMapper';
import ShiftViewModel from './shiftViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { EmployeeDepartmentHistoryTableComponent } from '../shared/employeeDepartmentHistoryTable';

interface ShiftDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ShiftDetailComponentState {
  model?: ShiftViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ShiftDetailComponent extends React.Component<
  ShiftDetailComponentProps,
  ShiftDetailComponentState
> {
  state = {
    model: new ShiftViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Shifts + '/edit/' + this.state.model!.shiftID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.ShiftClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Shifts +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ShiftMapper();

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
              <h3>End Time</h3>
              <p>{String(this.state.model!.endTime)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div>
              <h3>Start Time</h3>
              <p>{String(this.state.model!.startTime)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>EmployeeDepartmentHistories</h3>
            <EmployeeDepartmentHistoryTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Shifts +
                '/' +
                this.state.model!.shiftID +
                '/' +
                ApiRoutes.EmployeeDepartmentHistories
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

export const WrappedShiftDetailComponent = Form.create({
  name: 'Shift Detail',
})(ShiftDetailComponent);


/*<Codenesium>
    <Hash>4e508a040fcbeac030964b4003bfbee5</Hash>
</Codenesium>*/
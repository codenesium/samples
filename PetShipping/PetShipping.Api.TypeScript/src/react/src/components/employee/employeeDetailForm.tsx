import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EmployeeMapper from './employeeMapper';
import EmployeeViewModel from './employeeViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { CustomerCommunicationTableComponent } from '../shared/customerCommunicationTable';
import { PipelineStepTableComponent } from '../shared/pipelineStepTable';
import { PipelineStepNoteTableComponent } from '../shared/pipelineStepNoteTable';

interface EmployeeDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface EmployeeDetailComponentState {
  model?: EmployeeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class EmployeeDetailComponent extends React.Component<
  EmployeeDetailComponentProps,
  EmployeeDetailComponentState
> {
  state = {
    model: new EmployeeViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Employees + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.EmployeeClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Employees +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new EmployeeMapper();

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
              <h3>First Name</h3>
              <p>{String(this.state.model!.firstName)}</p>
            </div>
            <div>
              <h3>Is Sales Person</h3>
              <p>{String(this.state.model!.isSalesPerson)}</p>
            </div>
            <div>
              <h3>Is Shipper</h3>
              <p>{String(this.state.model!.isShipper)}</p>
            </div>
            <div>
              <h3>Last Name</h3>
              <p>{String(this.state.model!.lastName)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>CustomerCommunications</h3>
            <CustomerCommunicationTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Employees +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.CustomerCommunications
              }
            />
          </div>
          <div>
            <h3>PipelineSteps</h3>
            <PipelineStepTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Employees +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.PipelineSteps
              }
            />
          </div>
          <div>
            <h3>PipelineStepNotes</h3>
            <PipelineStepNoteTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Employees +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.PipelineStepNotes
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

export const WrappedEmployeeDetailComponent = Form.create({
  name: 'Employee Detail',
})(EmployeeDetailComponent);


/*<Codenesium>
    <Hash>fbc3522dd2c0e6f9db8058a94888daff</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/
import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EmployeeMapper from './employeeMapper';
import EmployeeViewModel from './employeeViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Employees +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.EmployeeClientResponseModel;

          console.log(response);

          let mapper = new EmployeeMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
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
              <h3>firstName</h3>
              <p>{String(this.state.model!.firstName)}</p>
            </div>
            <div>
              <h3>isSalesPerson</h3>
              <p>{String(this.state.model!.isSalesPerson)}</p>
            </div>
            <div>
              <h3>isShipper</h3>
              <p>{String(this.state.model!.isShipper)}</p>
            </div>
            <div>
              <h3>lastName</h3>
              <p>{String(this.state.model!.lastName)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>CustomerCommunications</h3>
            <CustomerCommunicationTableComponent
              id={this.state.model!.id}
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
              id={this.state.model!.id}
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
              id={this.state.model!.id}
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
    <Hash>3a98ed220fd12cae1c03911429d3248f</Hash>
</Codenesium>*/
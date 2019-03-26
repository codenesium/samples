import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EmployeeMapper from './employeeMapper';
import EmployeeViewModel from './employeeViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { EmployeeDepartmentHistoryTableComponent } from '../shared/employeeDepartmentHistoryTable';
import { EmployeePayHistoryTableComponent } from '../shared/employeePayHistoryTable';
import { JobCandidateTableComponent } from '../shared/jobCandidateTable';

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
      ClientRoutes.Employees + '/edit/' + this.state.model!.businessEntityID
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
              <h3>Birth Date</h3>
              <p>{String(this.state.model!.birthDate)}</p>
            </div>
            <div>
              <h3>Current Flag</h3>
              <p>{String(this.state.model!.currentFlag)}</p>
            </div>
            <div>
              <h3>Gender</h3>
              <p>{String(this.state.model!.gender)}</p>
            </div>
            <div>
              <h3>Hire Date</h3>
              <p>{String(this.state.model!.hireDate)}</p>
            </div>
            <div>
              <h3>Job Title</h3>
              <p>{String(this.state.model!.jobTitle)}</p>
            </div>
            <div>
              <h3>Login I D</h3>
              <p>{String(this.state.model!.loginID)}</p>
            </div>
            <div>
              <h3>Marital Status</h3>
              <p>{String(this.state.model!.maritalStatu)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>National I D Number</h3>
              <p>{String(this.state.model!.nationalIDNumber)}</p>
            </div>
            <div>
              <h3>Organization Level</h3>
              <p>{String(this.state.model!.organizationLevel)}</p>
            </div>
            <div>
              <h3>Rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
            <div>
              <h3>Salaried Flag</h3>
              <p>{String(this.state.model!.salariedFlag)}</p>
            </div>
            <div>
              <h3>Sick Leave Hours</h3>
              <p>{String(this.state.model!.sickLeaveHour)}</p>
            </div>
            <div>
              <h3>Vacation Hours</h3>
              <p>{String(this.state.model!.vacationHour)}</p>
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
                ApiRoutes.Employees +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.EmployeeDepartmentHistories
              }
            />
          </div>
          <div>
            <h3>EmployeePayHistories</h3>
            <EmployeePayHistoryTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Employees +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.EmployeePayHistories
              }
            />
          </div>
          <div>
            <h3>JobCandidates</h3>
            <JobCandidateTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Employees +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.JobCandidates
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
    <Hash>22f3bdca019b1858d9a8ba017db767c3</Hash>
</Codenesium>*/
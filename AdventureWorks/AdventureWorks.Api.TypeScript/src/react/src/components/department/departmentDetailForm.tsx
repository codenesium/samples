import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DepartmentMapper from './departmentMapper';
import DepartmentViewModel from './departmentViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { EmployeeDepartmentHistoryTableComponent } from '../shared/employeeDepartmentHistoryTable';

interface DepartmentDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface DepartmentDetailComponentState {
  model?: DepartmentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class DepartmentDetailComponent extends React.Component<
  DepartmentDetailComponentProps,
  DepartmentDetailComponentState
> {
  state = {
    model: new DepartmentViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Departments + '/edit/' + this.state.model!.departmentID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.DepartmentClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Departments +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new DepartmentMapper();

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
              <h3>Group Name</h3>
              <p>{String(this.state.model!.groupName)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
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
                ApiRoutes.Departments +
                '/' +
                this.state.model!.departmentID +
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

export const WrappedDepartmentDetailComponent = Form.create({
  name: 'Department Detail',
})(DepartmentDetailComponent);


/*<Codenesium>
    <Hash>55c41617e9550a7fe3a43501bd55ce48</Hash>
</Codenesium>*/
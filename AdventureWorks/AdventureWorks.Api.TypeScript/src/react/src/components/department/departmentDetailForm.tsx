import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DepartmentMapper from './departmentMapper';
import DepartmentViewModel from './departmentViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Departments +
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
          let response = resp.data as Api.DepartmentClientResponseModel;

          console.log(response);

          let mapper = new DepartmentMapper();

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
              <h3>DepartmentID</h3>
              <p>{String(this.state.model!.departmentID)}</p>
            </div>
            <div>
              <h3>GroupName</h3>
              <p>{String(this.state.model!.groupName)}</p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
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
              businessEntityID={this.state.model!.businessEntityID}
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
    <Hash>848e5452f863bf61cd78288042d305b2</Hash>
</Codenesium>*/
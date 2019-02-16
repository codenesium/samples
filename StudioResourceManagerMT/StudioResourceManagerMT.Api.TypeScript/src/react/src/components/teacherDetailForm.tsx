import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../api/models';
import { UpdateResponse } from '../api/ApiObjects';
import Constants from '../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import TeacherMapper from '../mapping/teacherMapper';
import TeacherViewModel from '../viewmodels/teacherViewModel';

interface Props {
  model?: TeacherViewModel;
}

const TeacherDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="birthday" className={'col-sm-2 col-form-label'}>
          Birthday
        </label>
        <div className="col-sm-12">{model.model!.birthday}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="email" className={'col-sm-2 col-form-label'}>
          Email
        </label>
        <div className="col-sm-12">{model.model!.email}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="firstName" className={'col-sm-2 col-form-label'}>
          FirstName
        </label>
        <div className="col-sm-12">{model.model!.firstName}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="id" className={'col-sm-2 col-form-label'}>
          Id
        </label>
        <div className="col-sm-12">{model.model!.id}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="isDeleted" className={'col-sm-2 col-form-label'}>
          IsDeleted
        </label>
        <div className="col-sm-12">{model.model!.isDeleted}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="lastName" className={'col-sm-2 col-form-label'}>
          LastName
        </label>
        <div className="col-sm-12">{model.model!.lastName}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="phone" className={'col-sm-2 col-form-label'}>
          Phone
        </label>
        <div className="col-sm-12">{model.model!.phone}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="tenantId" className={'col-sm-2 col-form-label'}>
          TenantId
        </label>
        <div className="col-sm-12">{model.model!.tenantId}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="userId" className={'col-sm-2 col-form-label'}>
          UserId
        </label>
        <div className="col-sm-12">{model.model!.userId}</div>
      </div>
    </form>
  );
};

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface TeacherDetailComponentProps {
  match: IMatch;
}

interface TeacherDetailComponentState {
  model?: TeacherViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class TeacherDetailComponent extends React.Component<
  TeacherDetailComponentProps,
  TeacherDetailComponentState
> {
  state = {
    model: undefined,
    loading: false,
    loaded: false,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(Constants.ApiUrl + 'teachers/' + this.props.match.params.id, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Api.TeacherClientResponseModel;

          let mapper = new TeacherMapper();

          console.log(response);

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          let response = error.response.data as UpdateResponse<
            Api.TeacherClientRequestModel
          >;
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
          console.log(response);
        }
      );
  }
  render() {
    if (this.state.loading) {
      return <div>loading</div>;
    } else if (this.state.loaded) {
      return <TeacherDetailDisplay model={this.state.model} />;
    } else if (this.state.errorOccurred) {
      return <div>{this.state.errorMessage}</div>;
    } else {
      return <div />;
    }
  }
}


/*<Codenesium>
    <Hash>673cf51b4154d402670a87e9992ed4c0</Hash>
</Codenesium>*/
import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import TeacherMapper from './teacherMapper';
import TeacherViewModel from './teacherViewModel';

interface Props {
  history: any;
  model?: TeacherViewModel;
}

const TeacherDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.Teachers + '/edit/' + model.model!.id
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="birthday" className={'col-sm-2 col-form-label'}>
          Birthday
        </label>
        <div className="col-sm-12">{String(model.model!.birthday)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="email" className={'col-sm-2 col-form-label'}>
          Email
        </label>
        <div className="col-sm-12">{String(model.model!.email)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="firstName" className={'col-sm-2 col-form-label'}>
          FirstName
        </label>
        <div className="col-sm-12">{String(model.model!.firstName)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="id" className={'col-sm-2 col-form-label'}>
          Id
        </label>
        <div className="col-sm-12">{String(model.model!.id)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="lastName" className={'col-sm-2 col-form-label'}>
          LastName
        </label>
        <div className="col-sm-12">{String(model.model!.lastName)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="phone" className={'col-sm-2 col-form-label'}>
          Phone
        </label>
        <div className="col-sm-12">{String(model.model!.phone)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="userId" className={'col-sm-2 col-form-label'}>
          UserId
        </label>
        <div className="col-sm-12">{String(model.model!.userId)}</div>
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
  history: any;
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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Teachers +
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
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }
  render() {
    if (this.state.loading) {
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
    } else if (this.state.loaded) {
      return (
        <TeacherDetailDisplay
          history={this.props.history}
          model={this.state.model}
        />
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>e364dc1f7e2cca9859c16958ec397490</Hash>
</Codenesium>*/
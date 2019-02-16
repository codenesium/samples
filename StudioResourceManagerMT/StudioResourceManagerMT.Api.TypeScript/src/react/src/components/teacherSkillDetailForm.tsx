import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../api/models';
import { UpdateResponse } from '../api/ApiObjects';
import Constants from '../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import TeacherSkillMapper from '../mapping/teacherSkillMapper';
import TeacherSkillViewModel from '../viewmodels/teacherSkillViewModel';

interface Props {
  model?: TeacherSkillViewModel;
}

const TeacherSkillDetailDisplay = (model: Props) => {
  return (
    <form role="form">
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
        <label htmlFor="name" className={'col-sm-2 col-form-label'}>
          Name
        </label>
        <div className="col-sm-12">{model.model!.name}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="tenantId" className={'col-sm-2 col-form-label'}>
          TenantId
        </label>
        <div className="col-sm-12">{model.model!.tenantId}</div>
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

interface TeacherSkillDetailComponentProps {
  match: IMatch;
}

interface TeacherSkillDetailComponentState {
  model?: TeacherSkillViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class TeacherSkillDetailComponent extends React.Component<
  TeacherSkillDetailComponentProps,
  TeacherSkillDetailComponentState
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
      .get(Constants.ApiUrl + 'teacherskills/' + this.props.match.params.id, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Api.TeacherSkillClientResponseModel;

          let mapper = new TeacherSkillMapper();

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
            Api.TeacherSkillClientRequestModel
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
      return <TeacherSkillDetailDisplay model={this.state.model} />;
    } else if (this.state.errorOccurred) {
      return <div>{this.state.errorMessage}</div>;
    } else {
      return <div />;
    }
  }
}


/*<Codenesium>
    <Hash>e1414498d6907f8f50e4bdce4acaebe7</Hash>
</Codenesium>*/
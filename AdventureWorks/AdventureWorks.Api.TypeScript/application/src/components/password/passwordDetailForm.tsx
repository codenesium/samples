import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import PasswordMapper from './passwordMapper';
import PasswordViewModel from './passwordViewModel';

interface Props {
  model?: PasswordViewModel;
}

const PasswordDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="businessEntityID" className={'col-sm-2 col-form-label'}>
          BusinessEntityID
        </label>
        <div className="col-sm-12">{String(model.model!.businessEntityID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="passwordHash" className={'col-sm-2 col-form-label'}>
          PasswordHash
        </label>
        <div className="col-sm-12">{String(model.model!.passwordHash)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="passwordSalt" className={'col-sm-2 col-form-label'}>
          PasswordSalt
        </label>
        <div className="col-sm-12">{String(model.model!.passwordSalt)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="rowguid" className={'col-sm-2 col-form-label'}>
          Rowguid
        </label>
        <div className="col-sm-12">{String(model.model!.rowguid)}</div>
      </div>
    </form>
  );
};

interface IParams {
  businessEntityID: number;
}

interface IMatch {
  params: IParams;
}

interface PasswordDetailComponentProps {
  match: IMatch;
}

interface PasswordDetailComponentState {
  model?: PasswordViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PasswordDetailComponent extends React.Component<
  PasswordDetailComponentProps,
  PasswordDetailComponentState
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
        Constants.ApiUrl +
          'passwords/' +
          this.props.match.params.businessEntityID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.PasswordClientResponseModel;

          let mapper = new PasswordMapper();

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
      return <div>loading</div>;
    } else if (this.state.loaded) {
      return <PasswordDetailDisplay model={this.state.model} />;
    } else if (this.state.errorOccurred) {
      return (
        <div className="alert alert-danger">{this.state.errorMessage}</div>
      );
    } else {
      return <div />;
    }
  }
}


/*<Codenesium>
    <Hash>d4888ed1457fd5a1f52ba3cc22d471fe</Hash>
</Codenesium>*/
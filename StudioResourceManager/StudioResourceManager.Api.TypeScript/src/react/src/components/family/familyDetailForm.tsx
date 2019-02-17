import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import FamilyMapper from './familyMapper';
import FamilyViewModel from './familyViewModel';

interface Props {
  history: any;
  model?: FamilyViewModel;
}

const FamilyDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.Families + '/edit/' + model.model!.id
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="note" className={'col-sm-2 col-form-label'}>
          Notes
        </label>
        <div className="col-sm-12">{String(model.model!.note)}</div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="primaryContactEmail"
          className={'col-sm-2 col-form-label'}
        >
          Primary Contact Email
        </label>
        <div className="col-sm-12">
          {String(model.model!.primaryContactEmail)}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="primaryContactFirstName"
          className={'col-sm-2 col-form-label'}
        >
          Primary Contact First Name
        </label>
        <div className="col-sm-12">
          {String(model.model!.primaryContactFirstName)}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="primaryContactLastName"
          className={'col-sm-2 col-form-label'}
        >
          Primary Contact Last Name
        </label>
        <div className="col-sm-12">
          {String(model.model!.primaryContactLastName)}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="primaryContactPhone"
          className={'col-sm-2 col-form-label'}
        >
          Primary Contact Phone
        </label>
        <div className="col-sm-12">
          {String(model.model!.primaryContactPhone)}
        </div>
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

interface FamilyDetailComponentProps {
  match: IMatch;
  history: any;
}

interface FamilyDetailComponentState {
  model?: FamilyViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class FamilyDetailComponent extends React.Component<
  FamilyDetailComponentProps,
  FamilyDetailComponentState
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
          ApiRoutes.Families +
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
          let response = resp.data as Api.FamilyClientResponseModel;

          let mapper = new FamilyMapper();

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
        <FamilyDetailDisplay
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
    <Hash>4f29ed34a4c936b139dd23c72cbd0234</Hash>
</Codenesium>*/
import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import PersonMapper from './personMapper';
import PersonViewModel from './personViewModel';

interface Props {
  history: any;
  model?: PersonViewModel;
}

const PersonDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.People + '/edit/' + model.model!.businessEntityID
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label
          htmlFor="additionalContactInfo"
          className={'col-sm-2 col-form-label'}
        >
          AdditionalContactInfo
        </label>
        <div className="col-sm-12">
          {String(model.model!.additionalContactInfo)}
        </div>
      </div>
      <div className="form-group row">
        <label htmlFor="businessEntityID" className={'col-sm-2 col-form-label'}>
          BusinessEntityID
        </label>
        <div className="col-sm-12">{String(model.model!.businessEntityID)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="demographic" className={'col-sm-2 col-form-label'}>
          Demographics
        </label>
        <div className="col-sm-12">{String(model.model!.demographic)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="emailPromotion" className={'col-sm-2 col-form-label'}>
          EmailPromotion
        </label>
        <div className="col-sm-12">{String(model.model!.emailPromotion)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="firstName" className={'col-sm-2 col-form-label'}>
          FirstName
        </label>
        <div className="col-sm-12">{String(model.model!.firstName)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="lastName" className={'col-sm-2 col-form-label'}>
          LastName
        </label>
        <div className="col-sm-12">{String(model.model!.lastName)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="middleName" className={'col-sm-2 col-form-label'}>
          MiddleName
        </label>
        <div className="col-sm-12">{String(model.model!.middleName)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="nameStyle" className={'col-sm-2 col-form-label'}>
          NameStyle
        </label>
        <div className="col-sm-12">{String(model.model!.nameStyle)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="personType" className={'col-sm-2 col-form-label'}>
          PersonType
        </label>
        <div className="col-sm-12">{String(model.model!.personType)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="rowguid" className={'col-sm-2 col-form-label'}>
          Rowguid
        </label>
        <div className="col-sm-12">{String(model.model!.rowguid)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="suffix" className={'col-sm-2 col-form-label'}>
          Suffix
        </label>
        <div className="col-sm-12">{String(model.model!.suffix)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="title" className={'col-sm-2 col-form-label'}>
          Title
        </label>
        <div className="col-sm-12">{String(model.model!.title)}</div>
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

interface PersonDetailComponentProps {
  match: IMatch;
  history: any;
}

interface PersonDetailComponentState {
  model?: PersonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PersonDetailComponent extends React.Component<
  PersonDetailComponentProps,
  PersonDetailComponentState
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
          ApiRoutes.People +
          '/' +
          this.props.match.params.businessEntityID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.PersonClientResponseModel;

          let mapper = new PersonMapper();

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
        <PersonDetailDisplay
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
    <Hash>4e879d97c49f4597983e5c834e4fe75c</Hash>
</Codenesium>*/
import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import PetMapper from './petMapper';
import PetViewModel from './petViewModel';

interface Props {
  history: any;
  model?: PetViewModel;
}

const PetDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(ClientRoutes.Pets + '/edit/' + model.model!.id);
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="acquiredDate" className={'col-sm-2 col-form-label'}>
          AcquiredDate
        </label>
        <div className="col-sm-12">{String(model.model!.acquiredDate)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="breedId" className={'col-sm-2 col-form-label'}>
          BreedId
        </label>
        <div className="col-sm-12">
          {model.model!.breedIdNavigation!.toDisplay()}
        </div>
      </div>
      <div className="form-group row">
        <label htmlFor="description" className={'col-sm-2 col-form-label'}>
          Description
        </label>
        <div className="col-sm-12">{String(model.model!.description)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="id" className={'col-sm-2 col-form-label'}>
          Id
        </label>
        <div className="col-sm-12">{String(model.model!.id)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="penId" className={'col-sm-2 col-form-label'}>
          PenId
        </label>
        <div className="col-sm-12">
          {model.model!.penIdNavigation!.toDisplay()}
        </div>
      </div>
      <div className="form-group row">
        <label htmlFor="price" className={'col-sm-2 col-form-label'}>
          Price
        </label>
        <div className="col-sm-12">{String(model.model!.price)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="speciesId" className={'col-sm-2 col-form-label'}>
          SpeciesId
        </label>
        <div className="col-sm-12">
          {model.model!.speciesIdNavigation!.toDisplay()}
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

interface PetDetailComponentProps {
  match: IMatch;
  history: any;
}

interface PetDetailComponentState {
  model?: PetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PetDetailComponent extends React.Component<
  PetDetailComponentProps,
  PetDetailComponentState
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
          ApiRoutes.Pets +
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
          let response = resp.data as Api.PetClientResponseModel;

          let mapper = new PetMapper();

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
        <PetDetailDisplay
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
    <Hash>9ac8a52479b57e15a0c31776a98a9d77</Hash>
</Codenesium>*/
import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import StudioMapper from './studioMapper';
import StudioViewModel from './studioViewModel';

interface Props {
  history: any;
  model?: StudioViewModel;
}

const StudioDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(ClientRoutes.Studios + '/edit/' + model.model!.id);
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="address1" className={'col-sm-2 col-form-label'}>
          Address1
        </label>
        <div className="col-sm-12">{String(model.model!.address1)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="address2" className={'col-sm-2 col-form-label'}>
          Address2
        </label>
        <div className="col-sm-12">{String(model.model!.address2)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="city" className={'col-sm-2 col-form-label'}>
          City
        </label>
        <div className="col-sm-12">{String(model.model!.city)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="id" className={'col-sm-2 col-form-label'}>
          Id
        </label>
        <div className="col-sm-12">{String(model.model!.id)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="name" className={'col-sm-2 col-form-label'}>
          Name
        </label>
        <div className="col-sm-12">{String(model.model!.name)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="province" className={'col-sm-2 col-form-label'}>
          Province
        </label>
        <div className="col-sm-12">{String(model.model!.province)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="website" className={'col-sm-2 col-form-label'}>
          Website
        </label>
        <div className="col-sm-12">{String(model.model!.website)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="zip" className={'col-sm-2 col-form-label'}>
          Zip
        </label>
        <div className="col-sm-12">{String(model.model!.zip)}</div>
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

interface StudioDetailComponentProps {
  match: IMatch;
  history: any;
}

interface StudioDetailComponentState {
  model?: StudioViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class StudioDetailComponent extends React.Component<
  StudioDetailComponentProps,
  StudioDetailComponentState
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
          ApiRoutes.Studios +
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
          let response = resp.data as Api.StudioClientResponseModel;

          let mapper = new StudioMapper();

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
        <StudioDetailDisplay
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
    <Hash>e4806a05c426a8a1ce03c990ebf86c53</Hash>
</Codenesium>*/
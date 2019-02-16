import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import CountryRegionMapper from './countryRegionMapper';
import CountryRegionViewModel from './countryRegionViewModel';

interface Props {
  model?: CountryRegionViewModel;
}

const CountryRegionDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label
          htmlFor="countryRegionCode"
          className={'col-sm-2 col-form-label'}
        >
          CountryRegionCode
        </label>
        <div className="col-sm-12">
          {String(model.model!.countryRegionCode)}
        </div>
      </div>

      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="name" className={'col-sm-2 col-form-label'}>
          Name
        </label>
        <div className="col-sm-12">{String(model.model!.name)}</div>
      </div>
    </form>
  );
};

interface IParams {
  countryRegionCode: string;
}

interface IMatch {
  params: IParams;
}

interface CountryRegionDetailComponentProps {
  match: IMatch;
}

interface CountryRegionDetailComponentState {
  model?: CountryRegionViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class CountryRegionDetailComponent extends React.Component<
  CountryRegionDetailComponentProps,
  CountryRegionDetailComponentState
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
          'countryregions/' +
          this.props.match.params.countryRegionCode,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.CountryRegionClientResponseModel;

          let mapper = new CountryRegionMapper();

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
      return <CountryRegionDetailDisplay model={this.state.model} />;
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
    <Hash>9e0c58fd0fa74d6019d356cee1dca307</Hash>
</Codenesium>*/
import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import SpecialOfferMapper from './specialOfferMapper';
import SpecialOfferViewModel from './specialOfferViewModel';

interface Props {
  model?: SpecialOfferViewModel;
}

const SpecialOfferDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="category" className={'col-sm-2 col-form-label'}>
          Category
        </label>
        <div className="col-sm-12">{String(model.model!.category)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="description" className={'col-sm-2 col-form-label'}>
          Description
        </label>
        <div className="col-sm-12">{String(model.model!.description)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="discountPct" className={'col-sm-2 col-form-label'}>
          DiscountPct
        </label>
        <div className="col-sm-12">{String(model.model!.discountPct)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="endDate" className={'col-sm-2 col-form-label'}>
          EndDate
        </label>
        <div className="col-sm-12">{String(model.model!.endDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="maxQty" className={'col-sm-2 col-form-label'}>
          MaxQty
        </label>
        <div className="col-sm-12">{String(model.model!.maxQty)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="minQty" className={'col-sm-2 col-form-label'}>
          MinQty
        </label>
        <div className="col-sm-12">{String(model.model!.minQty)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="rowguid" className={'col-sm-2 col-form-label'}>
          Rowguid
        </label>
        <div className="col-sm-12">{String(model.model!.rowguid)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="specialOfferID" className={'col-sm-2 col-form-label'}>
          SpecialOfferID
        </label>
        <div className="col-sm-12">{String(model.model!.specialOfferID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="startDate" className={'col-sm-2 col-form-label'}>
          StartDate
        </label>
        <div className="col-sm-12">{String(model.model!.startDate)}</div>
      </div>
    </form>
  );
};

interface IParams {
  specialOfferID: number;
}

interface IMatch {
  params: IParams;
}

interface SpecialOfferDetailComponentProps {
  match: IMatch;
}

interface SpecialOfferDetailComponentState {
  model?: SpecialOfferViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class SpecialOfferDetailComponent extends React.Component<
  SpecialOfferDetailComponentProps,
  SpecialOfferDetailComponentState
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
          'specialoffers/' +
          this.props.match.params.specialOfferID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.SpecialOfferClientResponseModel;

          let mapper = new SpecialOfferMapper();

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
      return <SpecialOfferDetailDisplay model={this.state.model} />;
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
    <Hash>0cf3bba344ad5c5e16ac8f87bbaa370a</Hash>
</Codenesium>*/
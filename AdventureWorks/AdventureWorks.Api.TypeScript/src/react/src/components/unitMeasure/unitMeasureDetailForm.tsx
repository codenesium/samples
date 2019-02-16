import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import UnitMeasureMapper from './unitMeasureMapper';
import UnitMeasureViewModel from './unitMeasureViewModel';

interface Props {
  model?: UnitMeasureViewModel;
}

const UnitMeasureDetailDisplay = (model: Props) => {
  return (
    <form role="form">
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

      <div className="form-group row">
        <label htmlFor="unitMeasureCode" className={'col-sm-2 col-form-label'}>
          UnitMeasureCode
        </label>
        <div className="col-sm-12">{String(model.model!.unitMeasureCode)}</div>
      </div>
    </form>
  );
};

interface IParams {
  unitMeasureCode: string;
}

interface IMatch {
  params: IParams;
}

interface UnitMeasureDetailComponentProps {
  match: IMatch;
}

interface UnitMeasureDetailComponentState {
  model?: UnitMeasureViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class UnitMeasureDetailComponent extends React.Component<
  UnitMeasureDetailComponentProps,
  UnitMeasureDetailComponentState
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
          'unitmeasures/' +
          this.props.match.params.unitMeasureCode,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.UnitMeasureClientResponseModel;

          let mapper = new UnitMeasureMapper();

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
      return <UnitMeasureDetailDisplay model={this.state.model} />;
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
    <Hash>2e59cb0cf05212d8e3a3351472d20a4a</Hash>
</Codenesium>*/
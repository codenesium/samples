import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import RateMapper from './rateMapper';
import RateViewModel from './rateViewModel';

interface Props {
  history: any;
  model?: RateViewModel;
}

const RateDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(ClientRoutes.Rates + '/edit/' + model.model!.id);
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="amountPerMinute" className={'col-sm-2 col-form-label'}>
          Amount Per Minute
        </label>
        <div className="col-sm-12">{String(model.model!.amountPerMinute)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="teacherId" className={'col-sm-2 col-form-label'}>
          TeacherId
        </label>
        <div className="col-sm-12">
          {model.model!.teacherIdNavigation!.toDisplay()}
        </div>
      </div>
      <div className="form-group row">
        <label htmlFor="teacherSkillId" className={'col-sm-2 col-form-label'}>
          TeacherSkillId
        </label>
        <div className="col-sm-12">
          {model.model!.teacherSkillIdNavigation!.toDisplay()}
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

interface RateDetailComponentProps {
  match: IMatch;
  history: any;
}

interface RateDetailComponentState {
  model?: RateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class RateDetailComponent extends React.Component<
  RateDetailComponentProps,
  RateDetailComponentState
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
          ApiRoutes.Rates +
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
          let response = resp.data as Api.RateClientResponseModel;

          let mapper = new RateMapper();

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
        <RateDetailDisplay
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
    <Hash>e63015cf736f1b8b014857a49f98b906</Hash>
</Codenesium>*/
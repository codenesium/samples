import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import PostHistoryTypeViewModel from './postHistoryTypeViewModel';
import PostHistoryTypeMapper from './postHistoryTypeMapper';

interface Props {
  model?: PostHistoryTypeViewModel;
}

const PostHistoryTypeEditDisplay = (
  props: FormikProps<PostHistoryTypeViewModel>
) => {
  let status = props.status as UpdateResponse<
    Api.PostHistoryTypeClientRequestModel
  >;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof PostHistoryTypeViewModel] &&
      props.errors[name as keyof PostHistoryTypeViewModel]
    ) {
      response += props.errors[name as keyof PostHistoryTypeViewModel];
    }

    if (
      status &&
      status.validationErrors &&
      status.validationErrors.find(
        f => f.propertyName.toLowerCase() == name.toLowerCase()
      )
    ) {
      response += status.validationErrors.filter(
        f => f.propertyName.toLowerCase() == name.toLowerCase()
      )[0].errorMessage;
    }

    return response;
  };

  let errorExistForField = (name: string): boolean => {
    return errorsForField(name) != '';
  };

  return (
    <form onSubmit={props.handleSubmit} role="form">
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('rwType')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Type
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="rwType"
            className={
              errorExistForField('rwType')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('rwType') && (
            <small className="text-danger">{errorsForField('rwType')}</small>
          )}
        </div>
      </div>

      <button type="submit" className="btn btn-primary" disabled={false}>
        Submit
      </button>
      <br />
      <br />
      {status && status.success ? (
        <div className="alert alert-success">Success</div>
      ) : null}

      {status && !status.success ? (
        <div className="alert alert-danger">Error occurred</div>
      ) : null}
    </form>
  );
};

const PostHistoryTypeEdit = withFormik<Props, PostHistoryTypeViewModel>({
  mapPropsToValues: props => {
    let response = new PostHistoryTypeViewModel();
    response.setProperties(props.model!.id, props.model!.rwType);
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<PostHistoryTypeViewModel> = {};

    if (values.id == 0) {
      errors.id = 'Required';
    }
    if (values.rwType == '') {
      errors.rwType = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new PostHistoryTypeMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.PostHistoryTypes + '/' + values.id,

        mapper.mapViewModelToApiRequest(values),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as UpdateResponse<
            Api.PostHistoryTypeClientRequestModel
          >;
          actions.setStatus(response);
          console.log(response);
        },
        error => {
          console.log(error);
          actions.setStatus('Error from API');
        }
      )
      .then(response => {
        // cleanup
      });
  },

  displayName: 'PostHistoryTypeEdit',
})(PostHistoryTypeEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface PostHistoryTypeEditComponentProps {
  match: IMatch;
}

interface PostHistoryTypeEditComponentState {
  model?: PostHistoryTypeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PostHistoryTypeEditComponent extends React.Component<
  PostHistoryTypeEditComponentProps,
  PostHistoryTypeEditComponentState
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
          ApiRoutes.PostHistoryTypes +
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
          let response = resp.data as Api.PostHistoryTypeClientResponseModel;

          console.log(response);

          let mapper = new PostHistoryTypeMapper();

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
      return <PostHistoryTypeEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>d32a95c9b181342e9ffee3133133a4ed</Hash>
</Codenesium>*/